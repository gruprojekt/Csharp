﻿namespace Funkcje
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ValueA = new System.Windows.Forms.TextBox();
            this.ValueB = new System.Windows.Forms.TextBox();
            this.ValueC = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.minText = new System.Windows.Forms.TextBox();
            this.maxText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisX2.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea2.AxisY2.Crossing = -1.7976931348623157E+308D;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ImeMode = System.Windows.Forms.ImeMode.On;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 12);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.CustomProperties = "IsXAxisQuantitative=True";
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.MarkerSize = 1;
            series2.Name = "quadGraph";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(545, 537);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title2.Name = "quadGraph";
            this.chart1.Titles.Add(title2);
            // 
            // ValueA
            // 
            this.ValueA.Location = new System.Drawing.Point(591, 12);
            this.ValueA.Name = "ValueA";
            this.ValueA.Size = new System.Drawing.Size(100, 20);
            this.ValueA.TabIndex = 1;
            // 
            // ValueB
            // 
            this.ValueB.Location = new System.Drawing.Point(591, 38);
            this.ValueB.Name = "ValueB";
            this.ValueB.Size = new System.Drawing.Size(100, 20);
            this.ValueB.TabIndex = 2;
            // 
            // ValueC
            // 
            this.ValueC.Location = new System.Drawing.Point(591, 64);
            this.ValueC.Name = "ValueC";
            this.ValueC.Size = new System.Drawing.Size(100, 20);
            this.ValueC.TabIndex = 3;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(563, 474);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(209, 75);
            this.calculate.TabIndex = 4;
            this.calculate.Text = "calculate";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(591, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // minText
            // 
            this.minText.Location = new System.Drawing.Point(594, 251);
            this.minText.Name = "minText";
            this.minText.Size = new System.Drawing.Size(100, 20);
            this.minText.TabIndex = 6;
            // 
            // maxText
            // 
            this.maxText.Location = new System.Drawing.Point(594, 277);
            this.maxText.Name = "maxText";
            this.maxText.Size = new System.Drawing.Size(100, 20);
            this.maxText.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.maxText);
            this.Controls.Add(this.minText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.ValueC);
            this.Controls.Add(this.ValueB);
            this.Controls.Add(this.ValueA);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox ValueA;
        private System.Windows.Forms.TextBox ValueB;
        private System.Windows.Forms.TextBox ValueC;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox minText;
        private System.Windows.Forms.TextBox maxText;
    }
}
