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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.Workers". При необходимости она может быть перемещена или удалена.
            this.workersTableAdapter.Fill(this.libraryDataSet.Workers);
            workersBindingSource.DataSource = this.libraryDataSet;
            panel1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                workersBindingSource.EndEdit();
                workersTableAdapter.Update(this.libraryDataSet.Workers);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                workersTableAdapter.Update(this.libraryDataSet.Workers);
                panel1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                this.libraryDataSet.Workers.AddWorkersRow(this.libraryDataSet.Workers.NewWorkersRow());
                workersBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                workersBindingSource.ResetBindings(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            workersBindingSource.ResetBindings(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() {Filter="JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    workersBindingSource.RemoveCurrent();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                workersBindingSource.RemoveCurrent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                dataGridView1.DataSource = workersBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Workers
                            where o.ФИО.Contains(textBox7.Text) || o.Телефон.Contains(textBox7.Text) || o.Адрес.Contains(textBox7.Text)
                            select o;
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                dataGridView1.DataSource = workersBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Workers
                            where o.ФИО.Contains(textBox7.Text) || o.Телефон.Contains(textBox7.Text) || o.Адрес.Contains(textBox7.Text)
                            select o;
                dataGridView1.DataSource = query.ToList();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
