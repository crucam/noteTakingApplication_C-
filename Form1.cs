using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaking
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.Columns["Messages"].Visible = false;
            dataGridView1.Columns["Title"].Width = 175;
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            titleBox.Clear();
            messageBox.Clear();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (titleBox.Text.Length == 0 || messageBox.Text.Length == 0)
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            
            table.Rows.Add(titleBox.Text, messageBox.Text);

            titleBox.Clear();
            messageBox.Clear();
        }

        private void readBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                if (index > -1)
                {
                    titleBox.Text = table.Rows[index].ItemArray[0].ToString();
                    messageBox.Text = table.Rows[index].ItemArray[1].ToString();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a note to be read.");
            }
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                table.Rows[index].Delete();
            }

            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a note to delete.");
            }

            
        }
    }
}
