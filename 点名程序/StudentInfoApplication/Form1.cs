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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Entity> InfoList = new List<Entity>();

        private List<Entity> ShowList = new List<Entity>();

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "StudentInfo.txt";

            string content = File.ReadAllText(filePath);

            foreach (var item in Regex.Split(content, "\r\n"))
            {
                Entity info = new Entity();

                info.Id = item.Split(',')[0];
                info.Name = item.Split(',')[1];
                info._Class = item.Split(',')[2];

                this.InfoList.Add(info);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Random r = new Random(DateTime.Now.Millisecond);

            int index = r.Next(0, this.InfoList.Count);

            Entity info = this.InfoList[index];

            if (this.ShowList.IndexOf(info) != -1)
            {
                MessageBox.Show("点过了，不要再点了！态度好一点可以吗？");
                return;
            }

            this.ShowList.Add(info);

            this.listBox1.Items.Add(info.Id + info.Name + info._Class);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }

    public class Entity
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string _class;

        public string _Class
        {
            get { return _class; }
            set { _class = value; }
        }
    }
}
