using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        TestObj tescik = new TestObj();
        List<TextBox> listaTextboxow = new List<TextBox>();
        List<RadioButton> listaradio = new List<RadioButton>();
        List<CheckBox> listacheck = new List<CheckBox>();
        string pathob = "";
        public Form2()
        {
            InitializeComponent();
            vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            FormClosing += Form2_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            int n = Decimal.ToInt32(numericUpDown1.Value);
            tescik.ListaPytan.Add(textBox1.Text);
            tescik.Obraz.Add(checkBox1.Checked);
            tescik.JednaOdpowiedz.Add(checkBox2.Checked);
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
            for (int i = 0; i < n; i++)
            {
                Point polozenie_textboxa = new Point(x, y);
                listaTextboxow.Add(new TextBox());
                listaTextboxow[i].Location = polozenie_textboxa;
                listaTextboxow[i].Size  = new System.Drawing.Size(250,20);
                panel1.Controls.Add(listaTextboxow[i]);
                if (checkBox2.Checked == true)
                {
                    Point polozenie_radio = new Point(x+270, y);
                    listaradio.Add(new RadioButton());
                    listaradio[i].Location = polozenie_radio;
                    panel1.Controls.Add(listaradio[i]);
                }
                else
                {
                    Point polozenie_check = new Point(x+270, y);
                    listacheck.Add(new CheckBox());
                    listacheck[i].Location = polozenie_check;
                    panel1.Controls.Add(listacheck[i]);
                }
                y = y + 30;
                if (checkBox1.Checked == true)
                {
                    button5.Enabled = true;
                }
                else
                {
                    button5.Enabled = false;
                }
                button1.Enabled = false;
                button2.Enabled = true;
                button4.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tescik.ListaPoprawnych.Add(new List<bool>());
            tescik.ListaOdpowiedzi.Add(new List<string>());
            if (tescik.Obraz[tescik.ListaPytan.Count-1]==true)
            {
                tescik.PathList.Add(pathob); 
            }
            else
            {
                tescik.PathList.Add("BRAK");
            }
            for (int i = 0; i < listaTextboxow.Count; i++)
            {
                tescik.ListaOdpowiedzi[tescik.ListaPytan.Count - 1].Add(listaTextboxow[i].Text);
                if (tescik.JednaOdpowiedz[tescik.ListaPytan.Count - 1] == true)
                {
                    tescik.ListaPoprawnych[tescik.ListaPytan.Count - 1].Add(listaradio[i].Checked);
                }
                else
                {
                    tescik.ListaPoprawnych[tescik.ListaPytan.Count - 1].Add(listacheck[i].Checked);
                }
            }
            listacheck.Clear();
            listaradio.Clear();
            listaTextboxow.Clear();
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listaTextboxow.Clear();
            listacheck.Clear();
            listaradio.Clear();
            pictureBox1.ImageLocation = null;
            button5.Enabled = false;
            panel1.Controls.Clear();
            numericUpDown1.Value = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            button1.Enabled = true;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "(*.xml)|*.xml";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                StreamWriter wr = new StreamWriter(dialog.FileName); //To służy do zapisu danych
                XmlSerializer serializer = new XmlSerializer(typeof(TestObj)); //To będzie je formatowało :)
                serializer.Serialize(wr, tescik); //Serializujemy
                wr.Flush();
                wr.Close();
                Form1 asd = new Form1();
                this.Visible = false;
                asd.Show();
            }
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = (dlg.FileName);
            }
            pathob = dlg.FileName;

            dlg.Dispose();
        }
    }
}
