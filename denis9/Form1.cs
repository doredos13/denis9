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
            double xk = x0 + dx*10;
            // Количество точек графика 
            int count = (int)Math.Ceiling((xk - x0) / dx);
            
            double[] x = new double[count];
            
            double[] y1 = new double[count];
            // Расчитываем точки для графика функции 
            for (int i = 0; i < count && x0 <= (xk + dx / 2); i++)
            {
                // Вычисляем значение X 
                x[i] = x0 + dx * i;
                // Вычисляем значение функции в точке X 
                y1[i] = 0.0025 * b * Math.Pow(x0, 3) + Math.Sqrt(x0 + Math.Exp(0.82));
                x0 += dx;
            }
            // Настраиваем ось графика 
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = xk;
            // Определяем шаг сетки 
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            // Добавляем вычисленные значения в графики 
            chart1.Series[0].Points.DataBindXY(x, y1);

        }
    }
}
