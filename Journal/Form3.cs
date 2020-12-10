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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.admin admin = new Program.admin();
            List<string> articles = admin.view_waiting_articles();
            Form4 form4 = new Form4(articles,"Approve");
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.admin admin = new Program.admin();
            List<string> articles = admin.view_articles();
            Form4 form4 = new Form4(articles,"Delete");
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.admin admin = new Program.admin();
            List<string> articles = admin.view_articles();
            Form4 form4 = new Form4(articles, "View");
            form4.Show();
        }
    }
}
