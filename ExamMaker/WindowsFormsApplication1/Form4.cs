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
    public partial class Form4 : Form
    {
        TestObj Test = new TestObj();
        int numer = 1;
        List<Label> listalabel = new List<Label>();
        List<RadioButton> listaradio = new List<RadioButton>();
        List<CheckBox> listacheck = new List<CheckBox>();
        List<List<bool>> listauzytkownika = new List<List<bool>>();
        int poprawne = 0;
        int wszystkiepoprawne = 0;
        public Form4()
        {
            FormClosing += Form4_FormClosing;
            InitializeComponent();
            vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            panel1.AutoScroll = false;
            panel1.HorizontalScroll.Enabled = false;
            panel1.HorizontalScroll.Visible = false;
            panel1.HorizontalScroll.Maximum = 0;
            panel1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
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
            }
            int x = 0;
            int y = 0;
            label2.Text = numer.ToString();
            label1.Text = Test.ListaPytan[numer - 1];
            for (int i = 0; i < Test.ListaOdpowiedzi[numer - 1].Count(); i++)
            {
                Point polozenie_textboxa = new Point(x, y);
                listalabel.Add(new Label());
                listalabel[i].Location = polozenie_textboxa;
                listalabel[i].Size = new System.Drawing.Size(250, 20);
                panel1.Controls.Add(listalabel[i]);
                listalabel[i].Text = Test.ListaOdpowiedzi[numer - 1][i];
                if (Test.JednaOdpowiedz[numer - 1] == true)
                {
                    Point polozenie_radio = new Point(x + 270, y);
                    listaradio.Add(new RadioButton());
                    listaradio[i].Location = polozenie_radio;
                    panel1.Controls.Add(listaradio[i]);
                 //   listaradio[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                }
                else
                {
                    Point polozenie_check = new Point(x + 270, y);
                    listacheck.Add(new CheckBox());
                    listacheck[i].Location = polozenie_check;
                    panel1.Controls.Add(listacheck[i]);
                    //       listacheck[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                }
                y = y + 30;
                if (Test.Obraz[numer - 1] != false)
                {
                    pictureBox1.ImageLocation = (Test.PathList[numer - 1]);
                }
                button1.Enabled = false;
                button2.Enabled = true;
            }
        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listauzytkownika.Add(new List<bool>());
            if (Test.JednaOdpowiedz[numer - 1] == true)
            {
                for (int i = 0; i < Test.ListaPoprawnych[numer - 1].Count; i++)
                {
                    listauzytkownika[numer - 1].Add(listaradio[i].Checked);
                }
            }
            else
            {
                for (int i = 0; i < Test.ListaPoprawnych[numer - 1].Count; i++)
                {
                    listauzytkownika[numer - 1].Add(listacheck[i].Checked);
                }
            }
            if ((numer + 1) <= Test.ListaPytan.Count())
            {
 
                panel1.Controls.Clear();
                listacheck.Clear();
                listaradio.Clear();
                listalabel.Clear();
                pictureBox1.ImageLocation = null;
                numer++;
                int x = 0;
                int y = 0;
                label2.Text = numer.ToString();
                label1.Text = Test.ListaPytan[numer - 1];
                if (Test.Obraz[numer - 1] != false)
                {
                    pictureBox1.ImageLocation = (Test.PathList[numer - 1]);
                }
                for (int i = 0; i < Test.ListaOdpowiedzi[numer - 1].Count(); i++)
                {
                    Point polozenie_textboxa = new Point(x, y);
                    listalabel.Add(new Label());
                    listalabel[i].Location = polozenie_textboxa;
                    listalabel[i].Size = new System.Drawing.Size(250, 20);
                    panel1.Controls.Add(listalabel[i]);
                    listalabel[i].Text = Test.ListaOdpowiedzi[numer - 1][i];
                    if (Test.JednaOdpowiedz[numer - 1] == true)
                    {
                        Point polozenie_radio = new Point(x + 270, y);
                        listaradio.Add(new RadioButton());
                        listaradio[i].Location = polozenie_radio;
                        panel1.Controls.Add(listaradio[i]);
                     //   listaradio[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    else
                    {
                        Point polozenie_check = new Point(x + 270, y);
                        listacheck.Add(new CheckBox());
                        listacheck[i].Location = polozenie_check;
                        panel1.Controls.Add(listacheck[i]);
                     //   listacheck[i].Checked = Test.ListaPoprawnych[numer - 1][i];
                    }
                    y = y + 30;
                    button1.Enabled = false;
                    button2.Enabled = true;
                }
            }
            else
            {
                button2.Enabled = false;
                for(int i = 0; i < Test.ListaPytan.Count;i++)
                {
                    for (int j = 0; j < Test.ListaPoprawnych[i].Count; j++)
                    {
                        if (listauzytkownika[i][j] == Test.ListaPoprawnych[i][j] && Test.ListaPoprawnych[i][j] == true)
                        {
                            poprawne++;
                        }
                        if (Test.ListaPoprawnych[i][j] == true)
                        {
                            wszystkiepoprawne++;
                        }

                    }
                }
                label3.Text = poprawne.ToString() + " : poprawnych odpowiedzi z " + wszystkiepoprawne.ToString() + " mozliwych";

            }
        }
    } 
}
