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
    public partial class Form27 : Form
    {
        public Form27()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form27_Load(object sender, EventArgs e)
        {
            this.postTableAdapter.Fill(this.libraryDataSet.Post);
            postBindingSource.DataSource = this.libraryDataSet;
            panel1.Enabled = false;
        }
    }
}
