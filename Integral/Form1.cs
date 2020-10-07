using Integral.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integral
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _cbmMetod.SelectedIndex = 0;
        }
        private ICalculator GetCalculator()
        {
            switch (_cbmMetod.SelectedItem)
            {
                case "Метод трапеции":
                    return new TrapezoidCalc();
                case "Метод прямоугольника":
                    return new RectangleCalculator();
                case "Метод Симпсона":
                    return new Simpson();
            }
            return null;
        }
        private bool Calculate()
        {
            _chGraph.Series["Graph"].Points.Clear();
            double a = Convert.ToDouble(_tbMIN.Text);
            double b = Convert.ToDouble(_tbMAX.Text);
            int n = Convert.ToInt32(_nudN.Value);
            ICalculator calcul = GetCalculator();
            double result = 0;
            Stopwatch time = new Stopwatch();
            TimeSpan resulttime;
            if ((calcul is Simpson) && (n % 2 == 1))
            {
                _rtbResult.Text = "число шагов нечётное, выберите другой метод или чётное число шагов";
                return false;
            }
            if (a > b)
            {
                double t = a;
                a = b;
                b = t;
                _rtbResult.Text = "a > b, данные введены некоректно";
                return false;
            }
            for (int i = 1; i <= n; i+=n/5)
            {
                time.Restart();
                calcul.Calculate(a, b, i, x => 2 * x - Math.Log(11 * x) - 1);
                time.Stop();
                resulttime = time.Elapsed;
                _chGraph.Series["Graph"].Points.AddXY(i, resulttime.TotalMilliseconds);
            }
            result = calcul.Calculate(a, b, n, x => 2 * x - Math.Log(11 * x) - 1);
            _rtbResult.Text = $"Ответ: {result}";
            return true;
        }
        private void _btCalculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
