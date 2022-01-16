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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.Authorization". При необходимости она может быть перемещена или удалена.
            this.authorizationTableAdapter.Fill(this.libraryDataSet.Authorization);
            authorizationBindingSource.DataSource = this.libraryDataSet;
            panel1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                this.libraryDataSet.Authorization.AddAuthorizationRow(this.libraryDataSet.Authorization.NewAuthorizationRow());
                authorizationBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                authorizationBindingSource.ResetBindings(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            authorizationBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                authorizationBindingSource.EndEdit();
                authorizationTableAdapter.Update(this.libraryDataSet.Authorization);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                authorizationTableAdapter.Update(this.libraryDataSet.Authorization);
                panel1.Enabled = false;
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                authorizationBindingSource.RemoveCurrent();
        }
    }
}
