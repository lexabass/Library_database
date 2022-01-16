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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            panelBooksCondition.Visible = false;
            panelReaders.Visible = false;
            panelHall.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelBooksCondition.Visible == true)
                panelBooksCondition.Visible = false;
            if (panelReaders.Visible == true)
                panelReaders.Visible = false;
            if (panelHall.Visible == true)
                panelHall.Visible = false;
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

        private void btnBooks_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelBooks);
            openChildForm(new Form4());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form4());
            // open form
            hideSubMenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new Form8());
            // open form
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBooksCondition);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new Form9());
            // open form
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReaders);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new Form10());
            // open form
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new Form11());
            // open form
            hideSubMenu();
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

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panelHall);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form14());
            // open form
            hideSubMenu();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Form15());
            // open form
            hideSubMenu();
        }
    }
}
