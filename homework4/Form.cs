using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework4_Csh
{
    public partial class Form1 : Form
    {
        private Point mouseDownLocation;
        private bool isDragging = false;


        private Bitmap graphBitmap;

        public Form1()
        {
            InitializeComponent();

            int m= 1000;
            int n = 50;
            float lambda = 30;
            int t = 1;
            // generate attacks
            Adversary adv = new Adversary(m, n, lambda, t);
            adv.generateAttacks();

            // retrieve data
            List<List<int>> data2 = adv.GetLineChart2AttackList();

            LineChart chart2 = new LineChart(this, pictureBox2);
            chart2.DrawChart(this, data2);

            int secondHistogramPointOfInterest = 35;

            // retrieve histogram data
            Dictionary<int, int> histogramDistChart2 = adv.createHistoDistrib(data2, n);
            Dictionary<int, int> histogramDistChartToN = adv.createHistoDistribToN(data2, n, secondHistogramPointOfInterest);

            // generate Histograms
            Histogram histogram2 = new Histogram(this, chart2, histogramDistChart2, n);
            Histogram histogram2_1 = new Histogram(this, chart2, histogramDistChartToN, n, secondHistogramPointOfInterest);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }

}
