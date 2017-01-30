using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 FormaDruga = new Form2();
            FormaDruga.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 FormaTrzecia = new Form3();
            FormaTrzecia.Show();
        }
        private void MyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0) Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 FormaCzwarta = new Form4();
            FormaCzwarta.Show();
        }
    }
}
