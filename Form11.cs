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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.BlackList". При необходимости она может быть перемещена или удалена.
            this.blackListTableAdapter.Fill(this.libraryDataSet.BlackList);

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox11.Text))
            {
                dataGridView1.DataSource = blackListBindingSource;
            }
            else
            {
                var query = from o in this.libraryDataSet.BlackList
                            where o.ФИО.Contains(textBox11.Text) || o.Причина.Contains(textBox11.Text)
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
                this.libraryDataSet.BlackList.AddBlackListRow(this.libraryDataSet.BlackList.NewBlackListRow());
                blackListBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blackListBindingSource.ResetBindings(false);
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
            blackListBindingSource.ResetBindings(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                blackListBindingSource.EndEdit();
                blackListTableAdapter.Update(this.libraryDataSet.BlackList);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blackListTableAdapter.Update(this.libraryDataSet.BlackList);
                panel1.Enabled = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                blackListBindingSource.RemoveCurrent();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
