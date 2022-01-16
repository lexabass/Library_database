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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "libraryDataSet.DeletedWorkers". При необходимости она может быть перемещена или удалена.
            this.deletedWorkersTableAdapter.Fill(this.libraryDataSet.DeletedWorkers);
            deletedWorkersBindingSource1.DataSource = this.libraryDataSet;
            panel1.Enabled = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                panel1.Enabled = true;
                textBox1.Focus();
                this.libraryDataSet.DeletedWorkers.AddDeletedWorkersRow(this.libraryDataSet.DeletedWorkers.NewDeletedWorkersRow());
                deletedWorkersBindingSource.MoveLast();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                deletedWorkersBindingSource.ResetBindings(false);
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
            deletedWorkersBindingSource.ResetBindings(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                deletedWorkersBindingSource.EndEdit();
                deletedWorkersTableAdapter.Update(this.libraryDataSet.DeletedWorkers);

                panel1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                deletedWorkersTableAdapter.Update(this.libraryDataSet.DeletedWorkers);
                panel1.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить эту запись?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                deletedWorkersBindingSource.RemoveCurrent();
        }
    }
}
