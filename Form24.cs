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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form21());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            openChildForm(new Form27());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new Form25());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            openChildForm(new Form28());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form29());
        }
    }
}
