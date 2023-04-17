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

namespace bazaprojekt
{
    public partial class Form1 : Form
    {

        SqlConnection cnn;
        public string ip ="192.168.43.180";
        public string port = "51302";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;
            cnn.Open();
            MessageBox.Show("Otvorena konekcija...");
            cnn.Close();
        }
        private void login_button(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            string ID = "";
            string prava = "";
            string Fullname = "";

            SqlCommand naredba;
            SqlDataReader dataReader;
            SqlDataReader dataReader2;

            String sql, output = "";
            Spajanje cnn = Spajanje.Instance;

            sql = "select * from Users";

            cnn.Open();
            naredba = new SqlCommand(sql, cnn.GetConnection());
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                if(textBox1.Text.Equals(dataReader.GetValue(1))  && CreateMD5(textBox2.Text).Equals(dataReader.GetValue(2))){
                    ID = dataReader.GetValue(0).ToString();
                    username = dataReader.GetValue(1).ToString();
                    password = dataReader.GetValue(2).ToString();
                    Fullname = dataReader.GetValue(3).ToString();
                }
            }

            if (username == "")
            {
                    MessageBox.Show("kriva prijava");
            }

            naredba.Dispose();
            cnn.Close();

            sql = "select * from UserPrava ";
            cnn.Open();
            output = "";
            naredba = new SqlCommand(sql, cnn.GetConnection());
            dataReader2 = naredba.ExecuteReader();
            while (dataReader2.Read())
            {

                output = dataReader2.GetValue(0).ToString();

                if (dataReader2.GetValue(1).ToString() == ID && dataReader2.GetValue(3).ToString()=="True")
                {
                    prava=prava+ dataReader2.GetValue(2).ToString();
                    
                }
            }
          
            naredba.Dispose();
            cnn.Close();
            if (prava.Contains("1")  && prava.Contains("2") && prava.Contains("3") && prava.Contains("4") && prava.Contains("5") && prava.Contains("6"))
            {
                adminforma dF = new adminforma(username, password, ID,prava,Fullname);
                dF.Show();
            }
            else
            {
                glavni_menu dF = new glavni_menu(username, password, ID, prava, Fullname);
                dF.Show();
            }

        }

    
        
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public class Spajanje
        {
            private static Spajanje instance = null;
            private static readonly object padlock = new object();
            private SqlConnection connection;

            // Private constructor to prevent instantiation from outside
            public Spajanje()
            {
                // Initialize the SqlConnection here
                connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=room_management;Integrated Security=True;");
            }
            // Public method to get the singleton instance
            public static Spajanje Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Spajanje();
                        }
                        return instance;
                    }
                }
            }
            // Public method to open the SqlConnection
            public void Open()
            {
                connection.Open();
            }

            // Public method to close the SqlConnection
            public void Close()
            {
                connection.Close();
            }

            // Public method to get the SqlConnection object
            public SqlConnection GetConnection()
            {
                return connection;
            }

        }
    }
}
