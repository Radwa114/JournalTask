using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Journal
{
    public partial class Form2 : Form
    {
        public string authorName;
        public Form2(string Author_name)
        {
            InitializeComponent();
            authorName = Author_name;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter the title!");
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter the Description!");
            }
            else
            {
                Program.author author = new Program.author();
                Program.article article = new Program.article();
                article.title = textBox1.Text;
                article.description = textBox2.Text;
                article.author = authorName;
                author.create_article(article);
                MessageBox.Show("Article has been added to waiting list");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> articles = new List<string>();
            Program.author author = new Program.author();
            author.author_name = authorName;
            articles= author.view_articles();
            Form4 form4 = new Form4(articles, "View");
            form4.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button3.Visible = true;

        }
    }
}
