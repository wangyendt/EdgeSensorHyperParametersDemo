using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CCWin;
using CCWin.SkinControl;

namespace EdgeSensorHyperParametersDemo
{
    public partial class Form1 : CCSkinMain
    {
        private double module_noise_lower = 0;
        private double module_noise_upper = 20;
        private double module_drift_max_lower = 0;
        private double module_drift_max_upper = 10;
        private double module_drift_momentum_lower = 0;
        private double module_drift_momentum_upper = 1;
        private double structure_lf_lower = 10;
        private double structure_lf_upper = 1000;
        private double structure_rf_lower = 10;
        private double structure_rf_upper = 1000;
        private double structure_decay_lower = -2;
        private double structure_decay_upper = 3;
        private double structure_gap_lower = 1;
        private double structure_gap_upper = 50;
        private double structure_wn_lower = 0;
        private double structure_wn_upper = 20;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private double map(double value, double lower, double upper)
        {
            skrtbLog.ShowLog(value + " " + lower + " " + upper + " " + (lower + value / 100 * (upper - lower)));
            return lower + value / 100 * (upper - lower);
        }

        private void update_hyper_params()
        {
            List<SkinHScrollBar> hScrollBars = new List<SkinHScrollBar>();
            List<SkinLabel> skLbl = new List<SkinLabel>();
            StringBuilder sb = new StringBuilder();
            hScrollBars.AddRange(new[]
            {
                skinHScrollBar1,
                skinHScrollBar2,
                skinHScrollBar3,
                skinHScrollBar4,
                skinHScrollBar5,
                skinHScrollBar6,
                skinHScrollBar7,
                skinHScrollBar8
            });
            skLbl.AddRange(new[]
            {
                skinLabel8,skinLabel9,skinLabel10,
                skinLabel11,skinLabel12,skinLabel13,
                skinLabel14,skinLabel15
            });
            string[] param_name =
            {
                "module_noise_sigma", "module_drift_max",
                "module_drift_momentum",
                "structure_little_finger", "structure_ring_finger",
                "structure_decay", "structure_gap",
                "structure_noise_WN"
            };
            param_name.ToList().ForEach(x => sb.Append(x + "\t"));
            sb.Append("\r\n");
            double[] real_value =
            {
                map(hScrollBars[0].Value, module_noise_lower,module_noise_upper),
                map(hScrollBars[1].Value, module_drift_max_lower,module_drift_max_upper),
                map(hScrollBars[2].Value,module_drift_momentum_lower, module_drift_momentum_upper),
                map(hScrollBars[3].Value, structure_lf_lower, structure_lf_upper),
                map(hScrollBars[4].Value, structure_rf_lower, structure_rf_upper),
                Math.Pow(10, map(hScrollBars[5].Value,structure_decay_lower,structure_decay_upper )),
                map(hScrollBars[6].Value,structure_gap_lower,structure_gap_upper),
                map(hScrollBars[7].Value,structure_wn_lower,structure_wn_upper)
            };
            real_value.ToList().ForEach(x => sb.Append(x + "\t"));
            for (int i = 0; i < real_value.Length; i++)
            {
                skLbl[i].Text = real_value[i].ToString("0.00");
            }
            string path = "hyper_params.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(sb.ToString());
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        private void skinHScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            // module, signal~N(0, sigma^2)
            // sigma
            update_hyper_params();
        }

        private void skinHScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar3_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar4_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar5_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar6_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar7_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }

        private void skinHScrollBar8_ValueChanged(object sender, EventArgs e)
        {
            update_hyper_params();
        }
    }
}