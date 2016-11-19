using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace Nomina
{
    public partial class ImgEspere : UserControl
    {
        private int img;
        public ImgEspere()
        {
            InitializeComponent();
            img = 12;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bmp;
            img++;
            if (img > 12) img = 1;

            switch (img)
            {
                case 1: bmp = (Bitmap)Nomina.Properties.Resources._01;
                        break;
                case 2: bmp = (Bitmap)Nomina.Properties.Resources._02;
                        break;
                case 3: bmp = (Bitmap)Nomina.Properties.Resources._03;
                        break;
                case 4: bmp = (Bitmap)Nomina.Properties.Resources._04;
                        break;
                case 5: bmp = (Bitmap)Nomina.Properties.Resources._05;
                        break;
                case 6: bmp = (Bitmap)Nomina.Properties.Resources._06;
                        break;
                case 7: bmp = (Bitmap)Nomina.Properties.Resources._07;
                        break;
                case 8: bmp = (Bitmap)Nomina.Properties.Resources._08;
                        break;
                case 9: bmp = (Bitmap)Nomina.Properties.Resources._09;
                        break;
                case 10: bmp = (Bitmap)Nomina.Properties.Resources._10;
                        break;
                case 11: bmp = (Bitmap)Nomina.Properties.Resources._11;
                        break;
                case 12: bmp = (Bitmap)Nomina.Properties.Resources._12;
                        break;
                default: bmp = (Bitmap)Nomina.Properties.Resources._01;
                        break;
            }
            
            

            pictureBox1.Image = bmp;
        }

    }
}
