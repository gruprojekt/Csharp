using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        TestObj Test = new TestObj();
        int numer = 1;
        List<int> listaUzytych = new List<int>();// lista potrzebna do zabawy indeksami. Ta zawiera liste uzytych juz indeksow potrzebną dla funkcji ktora mi wyrzuca liczby randomowe
        List<int> listaPotrzebna = new List<int>();//a ta lista zawiera wymieszane indeksy ,dzieki powyzszej liscie i odpowiedniej funkcji indeksy sie nie potwarzaja
        List<Label> listalabel = new List<Label>();
        List<RadioButton> listaradio = new List<RadioButton>();
        List<CheckBox> listacheck = new List<CheckBox>();
        List<List<bool>> listauzytkownika = new List<List<bool>>();//zmienne lokalne
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

        private void button1_Click(object sender, EventArgs e)// otwieramy test (kod jest owiele bardziej rozwiniety po dodaniu opcji mieszania) zrobilem to aby nie musiec kombinowac w klasie. Mieszamy lokalnie.
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
                int y = 0;
                if (Test.isQuestionMixed == false)
                {
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
                else
                {
                    FillList(Test.ListaPytan.Count());
                    label2.Text = numer.ToString();
                    label1.Text = Test.ListaPytan[listaPotrzebna[numer - 1]];
                    for (int i = 0; i < Test.ListaOdpowiedzi[listaPotrzebna[numer - 1]].Count(); i++)
                    {
                        Point polozenie_textboxa = new Point(x, y);
                        listalabel.Add(new Label());
                        listalabel[i].Location = polozenie_textboxa;
                        listalabel[i].Size = new System.Drawing.Size(250, 20);
                        panel1.Controls.Add(listalabel[i]);
                        listalabel[i].Text = Test.ListaOdpowiedzi[listaPotrzebna[numer - 1]][i];
                        if (Test.JednaOdpowiedz[listaPotrzebna[numer - 1]] == true)
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
                        if (Test.Obraz[listaPotrzebna[numer - 1]] != false)
                        {
                            pictureBox1.ImageLocation = (Test.PathList[listaPotrzebna[numer - 1]]);
                        }
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                }
            }
            else
            {
                Form1 form1 = new Form1();
                form1.Visible = true;
                this.Visible = false;
            }


        }
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)// zamykanie
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
        private void button2_Click(object sender, EventArgs e)// kod bardziej rozbudowany przez opcje mieszania, nastepne pytanie
        {
            listauzytkownika.Add(new List<bool>());
            if (Test.isQuestionMixed == false)
            {
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
            }
            else
            {
                if (Test.JednaOdpowiedz[listaPotrzebna[numer - 1]] == true)
                {
                    for (int i = 0; i < Test.ListaPoprawnych[listaPotrzebna[numer- 1]].Count; i++)
                    {
                        listauzytkownika[numer - 1].Add(listaradio[i].Checked);
                    }
                }
                else
                {
                    for (int i = 0; i < Test.ListaPoprawnych[listaPotrzebna[numer - 1]].Count; i++)
                    {
                        listauzytkownika[numer - 1].Add(listacheck[i].Checked);
                    }
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
                if (Test.isQuestionMixed == false)
                {
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
                    label2.Text = numer.ToString();
                    label1.Text = Test.ListaPytan[listaPotrzebna[numer - 1]];
                    if (Test.Obraz[listaPotrzebna[numer - 1]] != false)
                    {
                        pictureBox1.ImageLocation = (Test.PathList[listaPotrzebna[numer - 1]]);
                    }
                    for (int i = 0; i < Test.ListaOdpowiedzi[listaPotrzebna[numer - 1]].Count(); i++)
                    {
                        Point polozenie_textboxa = new Point(x, y);
                        listalabel.Add(new Label());
                        listalabel[i].Location = polozenie_textboxa;
                        listalabel[i].Size = new System.Drawing.Size(250, 20);
                        panel1.Controls.Add(listalabel[i]);
                        listalabel[i].Text = Test.ListaOdpowiedzi[listaPotrzebna[numer - 1]][i];
                        if (Test.JednaOdpowiedz[listaPotrzebna[numer - 1]] == true)
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
            }
            else
            {
                button2.Enabled = false;
                if (!Test.isQuestionMixed)
                {
                    for (int i = 0; i < Test.ListaPytan.Count; i++)
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
                else
                {
                    for (int i = 0; i < Test.ListaPytan.Count; i++)
                    { 
                        for (int j = 0; j < Test.ListaPoprawnych[listaPotrzebna[i]].Count; j++)
                        {
                            if (listauzytkownika[i][j] == Test.ListaPoprawnych[listaPotrzebna[i]][j] && Test.ListaPoprawnych[listaPotrzebna[i]][j] == true)
                            {
                                poprawne++;
                            }
                            if (Test.ListaPoprawnych[listaPotrzebna[i]][j] == true)
                            {
                                wszystkiepoprawne++;
                            }

                        }
                    }
                    label3.Text = poprawne.ToString() + " : poprawnych odpowiedzi z " + wszystkiepoprawne.ToString() + " mozliwych";
                }
            }
        }
        public int Shuffle(int a)//funkcja ktora wyrzuca liczbe randomową nie potwarzająca sie indeksach (a to ilosc pytan)
        { 
                Random rnd = new Random();
                int liczba = 0;
                bool OK = true;
                while (OK)
                {
                    liczba = rnd.Next(0,(a));
                    if (!listaUzytych.Contains(liczba) )
                    {
                        listaUzytych.Add(liczba);
                        OK = false;
                    }
                }
            return liczba;
        }
        public void FillList(int a)// tutaj wypelniamy liste indeksow aby moc w innej kolejnosci wyrzucac pytania
        {
            for (int i = 0; i < a; i++)
            {
                this.listaPotrzebna.Add(Shuffle(a));
            }
        }
    } 
}
