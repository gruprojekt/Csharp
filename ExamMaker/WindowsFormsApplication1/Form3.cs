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
    public partial class Form3 : Form
    {
        TestObj Test = new TestObj(); // pusty test czekajacy na dane
        int numer = 1;
        List<TextBox> listaTextboxow = new List<TextBox>();
        List<RadioButton> listaradio = new List<RadioButton>();
        List<CheckBox> listacheck = new List<CheckBox>(); // lokalne zmienne 
        public Form3()
        {
            InitializeComponent();
            FormClosing += Form3_FormClosing;
            vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; }; // poprawnie dzialajacy scroll
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e) // otwieramy xml z zserializowanym obiektem
        {
      
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.xml) | *.xml";
            openFileDialog1.Title = "Wybierz test";


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader r = new StreamReader(openFileDialog1.FileName);
                XmlSerializer serializer = new XmlSerializer(typeof(TestObj));
                Test = (TestObj)serializer.Deserialize(r);
                r.Close();
                int x = 0;
                int y = 0;// wspolrzedne tworzenia 
                label2.Text = numer.ToString();
                textBox1.Text = Test.ListaPytan[numer - 1];
                for (int i = 0; i < Test.ListaOdpowiedzi[numer - 1].Count(); i++) // wrzucamy odpowiedzi
                {
                    Point polozenie_textboxa = new Point(x, y);
                    listaTextboxow.Add(new TextBox());
                    listaTextboxow[i].Location = polozenie_textboxa;
                    listaTextboxow[i].Size = new System.Drawing.Size(250, 20);
                    panel1.Controls.Add(listaTextboxow[i]);
                    listaTextboxow[i].Text = Test.ListaOdpowiedzi[numer - 1][i];
                    if (Test.JednaOdpowiedz[numer - 1] == true)
                    {
                        Point polozenie_radio = new Point(x + 270, y);
                        listaradio.Add(new RadioButton());
                        listaradio[i].Location = polozenie_radio;
                        panel1.Controls.Add(listaradio[i]);
                        listaradio[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    else
                    {
                        Point polozenie_check = new Point(x + 270, y);
                        listacheck.Add(new CheckBox());
                        listacheck[i].Location = polozenie_check;
                        panel1.Controls.Add(listacheck[i]);
                        listacheck[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    y = y + 30;
                    if (Test.Obraz[numer - 1] != false)
                    {
                        pictureBox1.ImageLocation = (Test.PathList[numer - 1]);
                    }
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            else
            {
                Form1 forma1 = new Form1();
                this.Visible = false;
                forma1.Visible = true;
            }
           
        }

        private void button2_Click(object sender, EventArgs e)// zapisujemy zmiany w lokalnych zmieniach
        {

            for (int i = 0; i < listaTextboxow.Count; i++)
            {
                Test.ListaOdpowiedzi[numer - 1][i] = listaTextboxow[i].Text;
                if (Test.JednaOdpowiedz[numer - 1] == true)
                {
                    Test.ListaPoprawnych[numer - 1][i] = listaradio[i].Checked;
                }
                else
                {
                    Test.ListaPoprawnych[numer - 1][i] = listacheck[i].Checked;
                }
            }
            listacheck.Clear();
            listaradio.Clear();
            listaTextboxow.Clear();
            button2.Enabled = false;
            button3.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)// nastepne pytanie
        {
            if ((numer+1) <= Test.ListaPytan.Count())
            {
                panel1.Controls.Clear();
                listacheck.Clear();
                listaradio.Clear();
                listaTextboxow.Clear();
                pictureBox1.ImageLocation = null;
                numer++;
            int x = 0;
            int y = 0;
            label2.Text = numer.ToString();
            textBox1.Text = Test.ListaPytan[numer - 1];
                if (Test.Obraz[numer - 1] != false)
                {
                    pictureBox1.ImageLocation = (Test.PathList[numer - 1]);
                }
                for (int i = 0; i < Test.ListaOdpowiedzi[numer - 1].Count(); i++)
                {
                    Point polozenie_textboxa = new Point(x, y);
                    listaTextboxow.Add(new TextBox());
                    listaTextboxow[i].Location = polozenie_textboxa;
                    listaTextboxow[i].Size = new System.Drawing.Size(250, 20);
                    panel1.Controls.Add(listaTextboxow[i]);
                    listaTextboxow[i].Text = Test.ListaOdpowiedzi[numer - 1][i];
                    if (Test.JednaOdpowiedz[numer - 1] == true)
                    {
                        Point polozenie_radio = new Point(x + 270, y);
                        listaradio.Add(new RadioButton());
                        listaradio[i].Location = polozenie_radio;
                        panel1.Controls.Add(listaradio[i]);
                        listaradio[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    else
                    {
                        Point polozenie_check = new Point(x + 270, y);
                        listacheck.Add(new CheckBox());
                        listacheck[i].Location = polozenie_check;
                        panel1.Controls.Add(listacheck[i]);
                        listacheck[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    y = y + 30;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = true;
                }

            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)// zapisujemy
        {
            if (checkBox1.Checked == true)
            {
                Test.isQuestionMixed = true;
            }
            else
            {
                Test.isQuestionMixed = false;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "(*.xml)|*.xml";
            dialog.ShowDialog();

            if (dialog.FileName != "")
            {
                StreamWriter wr = new StreamWriter(dialog.FileName); //To służy do zapisu danych
                XmlSerializer serializer = new XmlSerializer(typeof(TestObj)); //To będzie je formatowało :)
                serializer.Serialize(wr, Test); //Serializujemy
                wr.Flush();
                wr.Close();
                Form1 asd = new Form1();
                this.Close();
                asd.Show();
            }
        }
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)//poprawne zamykanie
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
    
}
