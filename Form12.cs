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
    public partial class Form12 : Form
    {

        public Form12()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelWorkers.Visible = false;
            panelFinans.Visible = false;
            panelCompany.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelWorkers.Visible == true)
                panelWorkers.Visible = false;
            if (panelFinans.Visible == true)
                panelFinans.Visible = false;
            if (panelCompany.Visible == true)
                panelCompany.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
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
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            showSubMenu(panelWorkers);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panelFinans);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCompany);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form16());
            // open form
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form17());
            // open form
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new Form18());
            // open form
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new Form19());
            // open form
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new Form20());
            // open form
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Form21());
            // open form
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new Form22());
            // open form
            hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form23());
            // open form
            hideSubMenu();
        }
    }
}
