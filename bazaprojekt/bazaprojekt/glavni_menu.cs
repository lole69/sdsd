using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static bazaprojekt.Form1;

namespace bazaprojekt
{
    public partial class glavni_menu : Form
    {
        string username;
            string password;
        string ID;
        string prava;
        string Fullname;
        List<string> oddWords = new List<string>();

        string[] words5;
        string[] words4;
        string[] words3;
        string[] words2;
        string[] words;
        string zaposlati1;
        string zaposlati2;
        string zaposlati3;





        public glavni_menu(string usernamef, string passwordf, string IDf, string pravaf, string Fullnamef)
        {
            InitializeComponent();
            label1.Text = Fullnamef;
            username = usernamef;
            password = passwordf;
            ID = IDf;
            prava = pravaf;
            Fullname = Fullnamef;
        }

        private void glavni_menu_Load(object sender, EventArgs e)
        {
            SqlCommand naredba;
            SqlDataReader dataReader;

            String sql, output = "",output2 = "";
            Spajanje cnn = Spajanje.Instance;

            sql = "select * from Vremena";

            cnn.Open();
            naredba = new SqlCommand(sql, cnn.GetConnection());
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {

                output = output + DateTime.Parse(dataReader.GetValue(1).ToString()).ToString("HH:mm:s:") +";" ;
                output2 = output2 + DateTime.Parse(dataReader.GetValue(1).ToString()).ToString("dd-MM-yyyy")+";";
            }
            
            output.Replace(":0:", "");



             words = output.Split(new string[] {":0:"},StringSplitOptions.None);
             words2 = output2.Split(new string[] { ";" }, StringSplitOptions.None);

            cnn.Close();
            naredba.Dispose();

            SqlCommand naredba3;
            SqlDataReader dataReader3;

            String sql3, output4 = "";
            Spajanje cnn3 = Spajanje.Instance;

            sql3 = "select * from Prostorija";

            cnn3.Open();
            naredba3 = new SqlCommand(sql3, cnn3.GetConnection());
            dataReader3 = naredba3.ExecuteReader();
            while (dataReader3.Read())
            {
                output4 = output4 + dataReader3.GetValue(1)+";";

            }

             words3 = output4.Split(new string[] { ";" }, StringSplitOptions.None);


            cnn.Close();
            naredba.Dispose();


            SqlCommand naredba4;
            SqlDataReader dataReader4;

            String sql4, output5 = "";
            Spajanje cnn4 = Spajanje.Instance;

            sql4 = "select * from Ponavljanja";

            cnn4.Open();
            naredba4 = new SqlCommand(sql4, cnn4.GetConnection());
            dataReader4 = naredba4.ExecuteReader();
            while (dataReader4.Read())
            {
                output5 = output5 + dataReader4.GetValue(1) + ";";

            }

             words4 = output5.Split(new string[] { ";" }, StringSplitOptions.None);


            cnn.Close();
            naredba.Dispose();





            SqlCommand naredba2;
            SqlDataReader dataReader2;

            String sql2, output3 = "";
            string aktivni = "";
            Spajanje cnn2 = Spajanje.Instance;

            sql2 = "select * from Rezervacije";

            cnn2.Open();
            naredba2 = new SqlCommand(sql2, cnn2.GetConnection());
            dataReader2 = naredba2.ExecuteReader();
            while (dataReader2.Read())
            {
                int broj = int.Parse(dataReader2.GetValue(3).ToString());
                int broj2 = int.Parse(dataReader2.GetValue(4).ToString());
                int broj3 = int.Parse(dataReader2.GetValue(5).ToString());
                int broj4 = int.Parse(dataReader2.GetValue(6).ToString());


                output3 = "";
                
                output3 = output3 + dataReader2.GetValue(1).ToString().Replace("0:00:00"," ") + dataReader2.GetValue(2).ToString() + "  "+ words[broj-1] +"  "+ words[broj2] + "  " + words3[broj3-1] +" "+ words4[broj4-1] +" "+dataReader2.GetValue(7).ToString();
                aktivni = dataReader2.GetValue(7).ToString()+";";
                listBox1.Items.Add(output3);

            }
             words5 = aktivni.Split(new string[] { ";" }, StringSplitOptions.None);



            cnn2.Close();
            naredba.Dispose();


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string word in words)
            {
                zaposlati1=zaposlati1+word;
            }
            foreach (string word in words3)
            {
                zaposlati2 = zaposlati2 + word + ";";
            }
            foreach (string word in words4)
            {
                zaposlati3 = zaposlati3 + word + ";";
            }

            rezervacija dF = new rezervacija(ID, zaposlati1, zaposlati2,zaposlati3);
            dF.Show();
        }
    }
}
