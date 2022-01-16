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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.Hall2". При необходимости она может быть перемещена или удалена.
            this.hall2TableAdapter.Fill(this.libraryDataSet.Hall2);

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                dataGridView1.DataSource = hall2BindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Hall2
                            where o.Состояние.Contains(textBox11.Text )
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
                this.libraryDataSet.Hall2.AddHall2Row(this.libraryDataSet.Hall2.NewHall2Row());
                hall2BindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hall2BindingSource.ResetBindings(false);
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
            hall2BindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                hall2BindingSource.EndEdit();
                hall2TableAdapter.Update(this.libraryDataSet.Hall2);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hall2TableAdapter.Update(this.libraryDataSet.Hall2);
                panel1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                hall2BindingSource.RemoveCurrent();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
