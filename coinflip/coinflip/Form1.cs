using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coinflip
{
    public partial class Form1 : Form
    {
        int glava = 0;
        int pismo = 0;
        public Form1()
        {
            InitializeComponent();
            label3.Text = "Šansa za glavu 50%";
            label4.Text = "Šansa za pismo 50%";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random coinFlip = new Random();
            int result = coinFlip.Next(1, 3);

            if (result == 1)
            {
                pictureBox1.ImageLocation = @"C:\Users\lovro\source\repos\CoinFlipApp-main\Heads.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                glava++;
                label1.Text = "Glava: " + glava;
            }

            else
            {
                pictureBox1.ImageLocation = @"C:\Users\lovro\source\repos\CoinFlipApp-main\Tails.png";
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pismo++;
                label2.Text = "Pismo: " + pismo;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
