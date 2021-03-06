﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funkcje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chart1.Series["quadGraph"].IsVisibleInLegend = false;
        }
        static double choose = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        // to ponizej nie potrzebne jezeli nie rozwiazujesz rownania
        //private double quadCalculator1(double a, double b, double c)
        //{
        //    double sqrtpart = b * b - 4 * a * c;
        //    double x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
        //    return x1;
        //}
        //private double quadCalculator2(double a, double b, double c)
        //{
        //    double sqrtpart = b * b - 4 * a * c;
        //    double x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
        //    return x2;

        //}
        private void calculate_Click(object sender, EventArgs e)// sprawdzamy ktory checkbox zaznaczony i liczymy "Y" ktore wrzucamy na grafa. X domyslnie jest od -5 do 5 ale mozna wpisac swoj uzupelniajac (od do)
        {
            if (choose == 2)
            {
                chart1.Series["quadGraph"].Points.Clear();
                chart1.Series["quadGraph"].Color = Color.Red;
                //chart1.Series["quadGraph"].
                double numberA = 0;
                double numberB = 0;
                double numberC = 0;
                try
                {
                    if (ValueA.Text != "")
                    {
                        numberA = Convert.ToDouble(ValueA.Text);
                    }
                    if (ValueB.Text != "")
                    {
                        numberB = Convert.ToDouble(ValueB.Text);
                    }
                    if (ValueC.Text != "")
                    {
                        numberC = Convert.ToDouble(ValueC.Text);
                    }

                    // double answer1 = quadCalculator1(numberA, numberB, numberC);
                    //double answer2 = quadCalculator2(numberA, numberB, numberC);
                    //quadOutput.Text += answer1 + " OR " + answer2;

                    //this.chart1.Series["quadGraph"].Points.AddXY(answer1, 0);
                    //this.chart1.Series["quadGraph"].Points.AddXY(answer2, 0);
                    //this.chart1.Series["quadGraph"].Points.AddXY(0, numberC);

                    // Do error checking here to determine validity of answers
                    // and which is the highest and lowest of the pair

                    //int count = 20;
                    //double[,] data = GetPoints(numberA, numberB, numberC, answer1, answer2, count);
                    //for (int i = 0; i < count; i++)
                    //{
                    //    this.chart1.Series["quadGraph"].Points.AddXY(data[i, 0], data[i, 1]);
                    //    label1.Text += data[i, 1].ToString();
                    //}
                    double min = -5;
                    double max = 5;
                    if (minText.Text != "")
                    {
                        min = double.Parse(minText.Text);
                    }
                    if (maxText.Text != "")
                    {
                        max = double.Parse(maxText.Text);
                    }


                    for (double i = min; i <= max; i += (max - min) / 20)
                    {
                        double pointX = i;
                        double pointY = GetY(numberA, numberB, numberC, pointX);
                        this.chart1.Series["quadGraph"].Points.AddXY(pointX, pointY);
                        label1.Text += pointY.ToString() + " , ";
                    }
                }
                catch
                {
                    MessageBox.Show("Problem z danymi, sprawdz jeszcze raz");
                }
            }
            if (choose == 1)
            {
                chart1.Series["quadGraph"].Points.Clear();
                double numberA = 0;
                double numberB = 0;
                try
                {
                    if (ValueA.Text != "")
                    {
                        numberA = Convert.ToDouble(ValueA.Text);
                    }
                    if (ValueB.Text != "")
                    {
                        numberB = Convert.ToDouble(ValueB.Text);
                    }

                    double min = -5;
                    double max = 5;
                    if (minText.Text != "")
                    {
                        min = double.Parse(minText.Text);
                    }
                    if (maxText.Text != "")
                    {
                        max = double.Parse(maxText.Text);
                    }


                    for (double i = min; i <= max; i += (max - min) / 20)
                    {
                        double pointX = i;
                        double pointY = (numberA * i) + numberB;
                        this.chart1.Series["quadGraph"].Points.AddXY(pointX, pointY);
                        label1.Text += pointY.ToString() + " , ";
                    }
                }
                catch { MessageBox.Show("Problem z danymi, sprawdz jeszcze raz"); }
            }
            if (choose == 3)
            {
                chart1.Series["quadGraph"].Points.Clear();
                double numberA = 0;
                double numberB = 0;
                double numberC = 0;
                double numberD = 0;
                try
                {
                    numberA = Convert.ToDouble(ValueA.Text);
                    numberB = Convert.ToDouble(ValueB.Text);
                    numberC = Convert.ToDouble(ValueC.Text);
                    numberD = Convert.ToDouble(ValueD.Text);

                    double min = -5;
                    double max = 5;
                    if (minText.Text != "")
                    {
                        min = double.Parse(minText.Text);
                    }
                    if (maxText.Text != "")
                    {
                        max = double.Parse(maxText.Text);
                    }

                    for (double i = min; i <= max; i += (max - min) / 20)
                    {
                        double pointX = i;
                        double pointY = numberA * i * i * i + numberB * i * i + numberC * i + numberD;
                        this.chart1.Series["quadGraph"].Points.AddXY(pointX, pointY);
                        label1.Text += pointY.ToString() + " , ";
                    }
                }
                catch
                {
                    MessageBox.Show("Problem z danymi, sprawdz jeszcze raz");

                }
            
            }
        }
        // to ponizej tez narazie nie potrzebne, tak jak wyzej (odpale to jezeli bedziemy musieli rozwiazywac rownania)
        //private double[,] GetPoints(double a, double b, double c, double xInterceptLow, double xInterceptHigh, int pointCount)
        //{
        //    double[,] output = new double[pointCount, 2];

        //    double subRange = xInterceptLow - xInterceptHigh;
        //    double delta = (2 * subRange) / pointCount;

        //    double xMin = xInterceptLow - (subRange / 2);
        //    double xMax = xInterceptHigh + (subRange / 2);

        //    for (int i = 0; i < pointCount; i++)
        //    {
        //        double x = xMin + (i * delta);
        //        double ans = GetY(a, b, c, x);
        //        output[i, 0] = x;
        //        output[i, 1] = ans;
        //    }
        //    return output;
        //}

        private double GetY(double a, double b, double c, double x)
        {
            double answer = (a * x * x) + (b * x) + c;
            return answer;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioChooser();
        }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            radioChooser();
        }
        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            radioChooser();
        }
        private void radioChooser()// udostepniamy potrzebne pola lub zamazujemy niepotrzebne
        {
            if (radioButton1.Checked == true)
            {
                ValueA.Visible = true;
                label2.Visible = true;

                ValueB.Visible = true;
                label3.Visible = true;

                ValueC.Visible = false;
                label4.Visible = false;

                ValueD.Visible = false;
                label7.Visible = false;

                calculate.Enabled = true;
                choose = 1;
            }
            if (radioButton2.Checked == true)
            {
                ValueA.Visible = true;
                label2.Visible = true;

                ValueB.Visible = true;
                label3.Visible = true;

                ValueC.Visible = true;
                label4.Visible = true;

                ValueD.Visible = false;
                label7.Visible = false;

                calculate.Enabled = true;
                choose = 2;
            }
            if (radioButton3.Checked == true)
            {
                ValueA.Visible = true;
                label2.Visible = true;

                ValueB.Visible = true;
                label3.Visible = true;

                ValueC.Visible = true;
                label4.Visible = true;

                ValueD.Visible = true;
                label7.Visible = true;

                calculate.Enabled = true;
                choose = 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "(*.png)|*.png";
                dialog.ShowDialog();
                chart1.SaveImage(dialog.FileName,System.Drawing.Imaging.ImageFormat.Png);
            }
            catch
            {
                MessageBox.Show("Nie udało się zapisać grafu");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {

            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Jeżeli nie zapisałeś postępów, mogą zostać utracone. Napewno chcesz zakończyć?", "Zamykanie aplikacji !", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    break;
            }
        }
    }
}
