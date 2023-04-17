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

                output = output + DateTime.Parse(dataReader.GetValue(1).ToString()).ToString("HH:mm:s:") ;
                output2 = output2 + DateTime.Parse(dataReader.GetValue(1).ToString()).ToString("dd-MM-yyyy")+";";
            }
            
            output.Replace(":0:", "");



            string[] words = output.Split(new string[] {":0:"},StringSplitOptions.None);
            string[] words2 = output2.Split(new string[] { ";" }, StringSplitOptions.None);

            cnn.Close();
            naredba.Dispose();


          

            SqlCommand naredba2;
            SqlDataReader dataReader2;

            String sql2, output3 = "";
            Spajanje cnn2 = Spajanje.Instance;

            sql2 = "select * from Rezervacije";

            cnn2.Open();
            naredba2 = new SqlCommand(sql2, cnn2.GetConnection());
            dataReader2 = naredba2.ExecuteReader();
            while (dataReader2.Read())
            {
                int broj = int.Parse(dataReader2.GetValue(3).ToString());
                int broj2 = int.Parse(dataReader2.GetValue(4).ToString());

                output3 = "";
                output3 = output3 + dataReader2.GetValue(1).ToString().Replace("0:00:00"," ") + dataReader2.GetValue(2).ToString() + "  "+ words[broj] +"  "+ words[broj2] + dataReader2.GetValue(5).ToString() + dataReader2.GetValue(6).ToString() + dataReader2.GetValue(7).ToString();
                listBox1.Items.Add(output3);

            }
            

       

            cnn2.Close();
            naredba.Dispose();


        }


    }
}
