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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.Readers". При необходимости она может быть перемещена или удалена.
            this.readersTableAdapter.Fill(this.libraryDataSet.Readers);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                dataGridView1.DataSource = readersBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Readers
                            where o.ФИО.Contains(textBox11.Text) || o.Телефон.Contains(textBox11.Text) || o.Адрес.Contains(textBox11.Text) || o.Возврат.Contains(textBox11.Text) || o.Состояние.Contains(textBox11.Text)
                            select o;
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox10.Focus();
                this.libraryDataSet.Readers.AddReadersRow(this.libraryDataSet.Readers.NewReadersRow());
                readersBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                readersBindingSource.ResetBindings(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox10.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            readersBindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                readersBindingSource.EndEdit();
                readersTableAdapter.Update(this.libraryDataSet.Readers);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                readersTableAdapter.Update(this.libraryDataSet.Readers);
                panel1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                readersBindingSource.RemoveCurrent();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
