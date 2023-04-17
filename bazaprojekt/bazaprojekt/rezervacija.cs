using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bazaprojekt
{
    public partial class rezervacija : Form
    {
        string ID;
        string vremena;
        string prostorija;
        string ponavljanje;

        string[] popisvremena;
        string[] popisprostorija;
        string[] popisponavljanja;

        string theDate;

        public rezervacija( string IDf, string vremenaf, string prostorijaf, string ponavljanjef)
        {
            InitializeComponent();
            ID = IDf;
            vremena = vremenaf;
            prostorija = prostorijaf;   
            ponavljanje = ponavljanjef;
            MessageBox.Show("" + ID + " " + " " + vremena + " " + prostorija + " " + ponavljanje);

        }

        
        private void rezervacija_Load(object sender, EventArgs e)
        {
            popisvremena = vremena.Split(new string[] { ";" }, StringSplitOptions.None);
            popisprostorija = prostorija.Split(new string[] { ";" }, StringSplitOptions.None);
            popisponavljanja = ponavljanje.Split(new string[] { ";" }, StringSplitOptions.None);

            foreach (string s in popisvremena) {
                comboBox1.Items.Add(s);
                    }
            foreach (string s in popisprostorija)
            {
                comboBox2.Items.Add(s);
            }
            foreach (string s in popisponavljanja)
            {
                comboBox3.Items.Add(s);
            }
            foreach (string s in popisvremena)
            {
                comboBox4.Items.Add(s);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            theDate  = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            MessageBox.Show(theDate);
        }
    }
}
