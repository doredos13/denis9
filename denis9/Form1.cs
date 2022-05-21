using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace denis9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Считываем с формы требуемые значения 
            double x0 = double.Parse(textBox1.Text);
            double dx = double.Parse(textBox2.Text);
            double b = 2.3;
            double z = 0;
            // Количество точек графика 
            int count = 10;
            // Массив значений X – общий для обоих графиков 
            double[] x = new double[count];
            // Два массива Y – по одному для каждого графика 
            double[] y1 = new double[count];
            double[] y2 = new double[count];
            
            // Расчитываем точки для графиков функций 
            for (int i = 0; i < count ; i++)
            {
                // Вычисляем значение X 
                x[i] = x0 + dx * i;
                // Вычисляем значение функции 1-го графика в точке X 
                y1[i] = 0.0025 * b * Math.Pow(x0, 3) + Math.Sqrt(x0 + Math.Exp(0.82));
                x0 += dx;
                // Вычисляем значение функции 2-го графика в точке X
                if (radioButton1.Checked)
                    z = Math.Sin(x0);
                else if (radioButton2.Checked)
                    z = Math.Cos(x0);
                else if (radioButton1.Checked)
                    z = Math.Exp(x0);
                y2[i] = 0.0025 * b * Math.Pow(z, 3) + Math.Sqrt(z + Math.Exp(0.82));
                z += dx;
            }
            // Настраиваем ось графика 
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = x0+dx*10;
            // Определяем шаг сетки 
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            // Добавляем вычисленные значения в графики 
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }
    }
}