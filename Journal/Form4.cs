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
    public partial class Form4 : Form
    {
        string Case ; 
        public Form4(List<string> articles , string header)
        {
            InitializeComponent();
            dataGridView1.Columns[3].HeaderText = header;
            Case = header;
            if (Case != "View")
            {
                dataGridView1.Columns[3].Visible = true;
                button1.Visible = true;

            }
            for (int i = 0; i < articles.Count; i++)
            {
                dataGridView1.Rows.Add(articles[i].Split('-'));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                if (Convert.ToBoolean(row.Cells["column"].Value) == true)
                {
                    Program.admin admin = new Program.admin();
                    if (Case == "Approve")
                    {
                        admin.approve_article(row.Cells["Title"].Value.ToString(), row.Cells["Description"].Value.ToString(), row.Cells["Author"].Value.ToString());

                    }
                    else if (Case == "Delete")
                    {
                        admin.delete_artice(row.Cells["Title"].Value.ToString(), row.Cells["Author"].Value.ToString());

                    }
                }

            }
            MessageBox.Show("Changes had saved successfully!");
            this.Close();
            
          
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
