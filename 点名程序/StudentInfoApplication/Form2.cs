using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace StudentInfoApplication
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "StudentInfo.txt";

            string content = File.ReadAllText(filePath);

            foreach (var item in Regex.Split(content, "\r\n"))
            {
                this.listBox1.Items.Add(item);
            }
        }
    }
}
