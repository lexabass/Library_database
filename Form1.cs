using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace Library
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nTopRect,
        int RightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Library.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text != "" && textBox2.Text != "")
            {
                con.Open();
                string login = "SELECT [Login], [Password], [PostID] FROM [Authorization] WHERE Login= '" + textBox1.Text + "' and Password= '" + textBox2.Text + "'";
                cmd = new OleDbCommand(login, con);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    string sss = Convert.ToString(dr["PostID"]);
                    if (sss == "100")
                    {
                        this.Hide();
                        Form2 form = new Form2();
                        form.Show();
                    }
                    else if (sss == "201")
                    {
                        this.Hide();
                        Form13 form = new Form13();
                        form.Show();
                    }
                    else if (sss == "300")
                    {
                        this.Hide();
                        Form12 form = new Form12();
                        form.Show();
                    }
                    else if (sss == "200")
                    {
                        this.Hide();
                        Form24 form = new Form24();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль, пожалуйста повторите попытку", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Focus();
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль, пожалуйста повторите попытку", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                    con.Close();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '•';
            }
        }

       
    }
}
