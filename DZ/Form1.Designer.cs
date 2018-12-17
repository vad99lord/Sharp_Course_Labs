namespace DZ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Open_file_button = new System.Windows.Forms.Button();
            this.textBox_time = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_words = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button_search_word = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_search_time = new System.Windows.Forms.TextBox();
            this.listBox_result = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.distanceNum = new System.Windows.Forms.TextBox();
            this.checkBox_Damerau = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_simple_search = new System.Windows.Forms.Button();
            this.textBox_simple_time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_threads = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxThreadCountAll = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonSaveReport = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Open_file_button
            // 
            this.Open_file_button.Location = new System.Drawing.Point(25, 14);
            this.Open_file_button.Name = "Open_file_button";
            this.Open_file_button.Size = new System.Drawing.Size(175, 48);
            this.Open_file_button.TabIndex = 0;
            this.Open_file_button.Text = "Чтение из файла";
            this.Open_file_button.UseVisualStyleBackColor = true;
            this.Open_file_button.Click += new System.EventHandler(this.Open_file_button_Click);
            // 
            // textBox_time
            // 
            this.textBox_time.Location = new System.Drawing.Point(429, 39);
            this.textBox_time.Name = "textBox_time";
            this.textBox_time.Size = new System.Drawing.Size(293, 26);
            this.textBox_time.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Время чтения из файла:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Количество уникальных слов в файле: ";
            // 
            // textBox_words
            // 
            this.textBox_words.Location = new System.Drawing.Point(542, 92);
            this.textBox_words.Name = "textBox_words";
            this.textBox_words.Size = new System.Drawing.Size(180, 26);
            this.textBox_words.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(226, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Введите слово для поиска: ";
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(455, 135);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(267, 26);
            this.textBox_search.TabIndex = 8;
            // 
            // button_search_word
            // 
            this.button_search_word.Location = new System.Drawing.Point(25, 264);
            this.button_search_word.Name = "button_search_word";
            this.button_search_word.Size = new System.Drawing.Size(175, 72);
            this.button_search_word.TabIndex = 9;
            this.button_search_word.Text = "Нечеткий поиск (параллельный)";
            this.button_search_word.UseVisualStyleBackColor = true;
            this.button_search_word.Click += new System.EventHandler(this.button_search_word_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Время нечеткого поиска: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_search_time
            // 
            this.textBox_search_time.Location = new System.Drawing.Point(436, 397);
            this.textBox_search_time.Name = "textBox_search_time";
            this.textBox_search_time.Size = new System.Drawing.Size(286, 26);
            this.textBox_search_time.TabIndex = 11;
            this.textBox_search_time.TextChanged += new System.EventHandler(this.textBox_search_time_TextChanged);
            // 
            // listBox_result
            // 
            this.listBox_result.FormattingEnabled = true;
            this.listBox_result.ItemHeight = 20;
            this.listBox_result.Location = new System.Drawing.Point(25, 473);
            this.listBox_result.Name = "listBox_result";
            this.listBox_result.Size = new System.Drawing.Size(693, 184);
            this.listBox_result.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(393, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Введите макимальное расстояние Левенштейна: ";
            // 
            // distanceNum
            // 
            this.distanceNum.Location = new System.Drawing.Point(622, 264);
            this.distanceNum.Name = "distanceNum";
            this.distanceNum.Size = new System.Drawing.Size(100, 26);
            this.distanceNum.TabIndex = 14;
            // 
            // checkBox_Damerau
            // 
            this.checkBox_Damerau.AutoSize = true;
            this.checkBox_Damerau.Location = new System.Drawing.Point(673, 224);
            this.checkBox_Damerau.Name = "checkBox_Damerau";
            this.checkBox_Damerau.Size = new System.Drawing.Size(22, 21);
            this.checkBox_Damerau.TabIndex = 15;
            this.checkBox_Damerau.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(226, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(371, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Отметьте флажок для Дамерау-Левенштейна ";
            // 
            // button_simple_search
            // 
            this.button_simple_search.Location = new System.Drawing.Point(25, 125);
            this.button_simple_search.Name = "button_simple_search";
            this.button_simple_search.Size = new System.Drawing.Size(175, 46);
            this.button_simple_search.TabIndex = 17;
            this.button_simple_search.Text = "Четкий поиск";
            this.button_simple_search.UseVisualStyleBackColor = true;
            this.button_simple_search.Click += new System.EventHandler(this.button_simple_search_Click);
            // 
            // textBox_simple_time
            // 
            this.textBox_simple_time.Location = new System.Drawing.Point(408, 179);
            this.textBox_simple_time.Name = "textBox_simple_time";
            this.textBox_simple_time.Size = new System.Drawing.Size(314, 26);
            this.textBox_simple_time.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Время четкого поиска: ";
            // 
            // textBox_threads
            // 
            this.textBox_threads.Location = new System.Drawing.Point(429, 314);
            this.textBox_threads.Name = "textBox_threads";
            this.textBox_threads.Size = new System.Drawing.Size(293, 26);
            this.textBox_threads.TabIndex = 21;
            this.textBox_threads.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(226, 317);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(170, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Количество потоков ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBoxThreadCountAll
            // 
            this.textBoxThreadCountAll.Location = new System.Drawing.Point(509, 354);
            this.textBoxThreadCountAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxThreadCountAll.Name = "textBoxThreadCountAll";
            this.textBoxThreadCountAll.ReadOnly = true;
            this.textBoxThreadCountAll.Size = new System.Drawing.Size(213, 26);
            this.textBoxThreadCountAll.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(226, 357);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(275, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Вычисленное количество потоков:";
            // 
            // buttonSaveReport
            // 
            this.buttonSaveReport.Location = new System.Drawing.Point(25, 671);
            this.buttonSaveReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveReport.Name = "buttonSaveReport";
            this.buttonSaveReport.Size = new System.Drawing.Size(210, 35);
            this.buttonSaveReport.TabIndex = 24;
            this.buttonSaveReport.Text = "Сохранение отчета";
            this.buttonSaveReport.UseVisualStyleBackColor = true;
            this.buttonSaveReport.Click += new System.EventHandler(this.buttonSaveReport_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(540, 671);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(178, 35);
            this.buttonExit.TabIndex = 25;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 720);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSaveReport);
            this.Controls.Add(this.textBoxThreadCountAll);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_threads);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_simple_time);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_simple_search);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_Damerau);
            this.Controls.Add(this.distanceNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.listBox_result);
            this.Controls.Add(this.textBox_search_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_search_word);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_words);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_time);
            this.Controls.Add(this.Open_file_button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Open_file_button;
        private System.Windows.Forms.TextBox textBox_time;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_words;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button_search_word;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_search_time;
        private System.Windows.Forms.ListBox listBox_result;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox distanceNum;
        private System.Windows.Forms.CheckBox checkBox_Damerau;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_simple_search;
        private System.Windows.Forms.TextBox textBox_simple_time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_threads;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxThreadCountAll;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonSaveReport;
        private System.Windows.Forms.Button buttonExit;
    }
}

