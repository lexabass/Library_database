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
    public partial class Form29 : Form
    {
        public Form29()
        {
            InitializeComponent();
        }

        private void Form29_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet4.Side". При необходимости она может быть перемещена или удалена.
            this.sideTableAdapter.Fill(this.libraryDataSet.Side);
            sideBindingSource.DataSource = this.libraryDataSet;
            panel1.Enabled = false;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                dataGridView1.DataSource = sideBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.Side
                            where o.Месяц.Contains(textBox11.Text) || o.Наименование.Contains(textBox11.Text)
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
                this.libraryDataSet.Side.AddSideRow(this.libraryDataSet.Side.NewSideRow());
                sideBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sideBindingSource.ResetBindings(false);
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
            sideBindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sideBindingSource.EndEdit();
                sideTableAdapter.Update(this.libraryDataSet.Side);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sideTableAdapter.Update(this.libraryDataSet.Side);
                panel1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                sideBindingSource.RemoveCurrent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
