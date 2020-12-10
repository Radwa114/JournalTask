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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter your name!");
            }
            else
            {
                if (comboBox1.Text == "Admin")
                {
                    if (textBox3.Text == "Samir")
                    {
                        Form3 form3 = new Form3();
                        this.Hide();
                        form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect admin name!");
                    }
                }
                else if (comboBox1.Text == "Author")
                {
                    string Author_name = textBox3.Text;
                    Program p = new Program();
                    List<string> names = p.get_authors_names();
                    if (names.Contains(Author_name))
                    {
                        Form2 form2 = new Form2(Author_name);
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Author name!");
                    }
                }
                else
                {
                    MessageBox.Show("Please choose option!");

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter title!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter Description!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Please enter author name!");
            }
            else
            {
                Program.article article = new Program.article();
                article.author = textBox4.Text;
                article.title = textBox1.Text;
                article.description = textBox2.Text;
                Program.author author = new Program.author();
                author.create_article(article);
                MessageBox.Show("Article has been added to waiting list");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
            }
        }
    }
}