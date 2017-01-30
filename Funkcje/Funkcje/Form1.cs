using System;
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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private double quadCalculator1(double a, double b, double c)
        {
            double sqrtpart = b * b - 4 * a * c;
            double x1 = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
            return x1;
        }
        private double quadCalculator2(double a, double b, double c)
        {
            double sqrtpart = b * b - 4 * a * c;
            double x2 = (-b - System.Math.Sqrt(sqrtpart)) / (2 * a);
            return x2;

        }
        private void calculate_Click(object sender, EventArgs e)
        {
            double numberA = Convert.ToDouble(ValueA.Text);
            double numberB = Convert.ToDouble(ValueB.Text);
            double numberC = Convert.ToDouble(ValueC.Text);
            double answer1 = quadCalculator1(numberA, numberB, numberC);
            double answer2 = quadCalculator2(numberA, numberB, numberC);
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
            double min = double.Parse(minText.Text);
            double max = double.Parse(maxText.Text);

            for (double i = min; i < max; i+=((max-min)/20))
            {
                double pointX = i;
                double pointY = GetY(numberA, numberB, numberC, pointX);
                this.chart1.Series["quadGraph"].Points.AddXY(pointX, pointY);
                label1.Text += pointY.ToString() + " , ";
            }
        }

        private double[,] GetPoints(double a, double b, double c, double xInterceptLow, double xInterceptHigh, int pointCount)
        {
            double[,] output = new double[pointCount, 2];

            double subRange = xInterceptLow - xInterceptHigh;
            double delta = (2 * subRange) / pointCount;

            double xMin = xInterceptLow - (subRange / 2);
            double xMax = xInterceptHigh + (subRange / 2);

            for (int i = 0; i < pointCount; i++)
            {
                double x = xMin + (i * delta);
                double ans = GetY(a, b, c, x);
                output[i, 0] = x;
                output[i, 1] = ans;
            }
            return output;
        }

        private double GetY(double a, double b, double c, double x)
        {
            double answer = (a * x * x) + (b * x) + c;
            return answer;
        }

    }
}
