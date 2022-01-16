using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.Books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.libraryDataSet.Books);
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "[Класс] Like '%" + "Научные" + "%'";
            dataGridView1.DataSource = bs;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void libraryDataSetBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void libraryDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void booksBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                dataGridView1.DataSource = booksBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Books
                            where o.Название.Contains(textBox11.Text) || o.Автор.Contains(textBox11.Text) || o.Издание.Contains(textBox11.Text) || o.Язык.Contains(textBox11.Text) || o.Наличие.Contains(textBox11.Text)
                            select o;
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                this.libraryDataSet.Books.AddBooksRow(this.libraryDataSet.Books.NewBooksRow());
                booksBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                booksBindingSource.ResetBindings(false);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            booksBindingSource.ResetBindings(false);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                booksBindingSource.EndEdit();
                booksTableAdapter.Update(this.libraryDataSet.Books);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                booksTableAdapter.Update(this.libraryDataSet.Books);
                panel1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                booksBindingSource.RemoveCurrent();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
