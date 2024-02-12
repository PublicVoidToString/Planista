using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planista.Forms
{
    public partial class AlgoChart : Form
    {
        public AlgoChart()
        {
            InitializeComponent();
        }

        public void AddMax(long x, long y)
        {
            chart1.Series["Top"].Points.Add(y,x);
        }
        public void AddAvg(long x, long y)
        {
            chart1.Series["Avg"].Points.Add(y, x);
           // if(chart1.ChartAreas[0].AxisY.Minimum<y) chart1.ChartAreas[0].AxisY.Minimum = y;
        }

        public void SetMax(long x)
        {
            chart1.ChartAreas[0].AxisY.Maximum = Math.Ceiling(x*1.1/1000)*1000;
            chart1.ChartAreas[0].AxisY.Minimum = 2000;
        }

    }
}
