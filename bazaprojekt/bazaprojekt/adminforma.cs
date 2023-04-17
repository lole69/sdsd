using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static bazaprojekt.Form1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace bazaprojekt
{

    
    public partial class adminforma : Form
    {
        string username;
        string password;
        string ID;
        string prava;
        string Fullname;

        SqlConnection cnn;
        public string output;
        public string ip = "192.168.43.180";
        public string port = "51302";
        public adminforma(string usernamef,string passwordf, string IDf, string pravaf ,string Fullnamef)
        {
            InitializeComponent();
            label1.Text = "Korisnik: " +Fullnamef;
            label2.Text = "Prava: admin";

            username = usernamef;
            password = passwordf;
            ID = IDf;
            prava = pravaf;
            Fullname = Fullnamef;
        }

        public void refresh()
        {
            listBox1.Items.Clear();
            SqlCommand naredba;
            SqlDataReader dataReader;
            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;

            String sql;
            sql = "select * from Users";
            cnn.Open();
            naredba = new SqlCommand(sql, cnn.GetConnection());
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                output = dataReader.GetValue(0).ToString() + ") " + dataReader.GetValue(3).ToString() + " " + dataReader.GetValue(4).ToString();
                listBox1.Items.Add(output);
            }

            cnn.Close();
            dataReader.Close();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            SqlCommand naredba;
            SqlDataReader dataReader;
            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;
            String sql;
            sql = "select * from Users";
            cnn.Open();
            naredba = new SqlCommand(sql, cnn.GetConnection());
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                output= dataReader.GetValue(0).ToString() +") "+ dataReader.GetValue(3).ToString() + " " + dataReader.GetValue(4).ToString();
                listBox1.Items.Add(output);
            }

            cnn.Close();
            dataReader.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ID = "";
            SqlCommand naredba;
            SqlDataReader dataReader2;

            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;
            cnn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "Insert into Users (Username,Password,Fullname,Active) values ('" + textBox1.Text + "','" + CreateMD5(textBox2.Text) + "','"+ textBox3.Text +"',1); ";
            naredba = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand.ExecuteNonQuery();
            cnn.Close();



            SqlDataReader dataReader;

            String sql2, output = "";
            sql2 = "select * from dbo.Users Where Username='"+textBox1.Text+"' ";
            cnn.Open();
            naredba = new SqlCommand(sql2, cnn.GetConnection());
            dataReader = naredba.ExecuteReader();
            while (dataReader.Read())
            {
                if (textBox1.Text.Equals(dataReader.GetValue(1)) && CreateMD5(textBox2.Text).Equals(dataReader.GetValue(2)))
                {
                    ID = dataReader.GetValue(0).ToString();
                  
                }
            }
            naredba.Dispose();
            cnn.Close();


            cnn.Open();
            string sql3 = "";
            if (checkBox1.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',1,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox1.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',1,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }

            if (checkBox2.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',2,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox2.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',2,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox3.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',3,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox3.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',3,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox4.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',4,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox4.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',4,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox5.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',5,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox5.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',5,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox6.Checked == true)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',6,1); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            if (checkBox6.Checked == false)
            {
                sql3 = "Insert into UserPrava (UserID,PravoID,Aktivno) values ('" + ID + "',6,0); ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            }
            cnn.Close();
            refresh();


            //3,2,1
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

        private void button2_Click(object sender, EventArgs e)
        {
          
            string trenutni = listBox1.SelectedItem.ToString();
            string[] kakgod = trenutni.ToString().Split(')');

            SqlCommand naredba;
            SqlDataReader dataReader2;

            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;
            cnn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "UPDATE Users SET Active = 'False' WHERE ID = '"+ kakgod[0].ToString() +"'; ";
            naredba = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand.ExecuteNonQuery();
            cnn.Close();
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string trenutni = listBox1.SelectedItem.ToString();
                string[] kakgod = trenutni.ToString().Split(')');

                SqlCommand naredba;
                SqlDataReader dataReader2;

                string cs; //connection string
                Spajanje cnn = Spajanje.Instance;
                cnn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql = "";
                sql = "UPDATE Users SET Active = 'True' WHERE ID = '" + kakgod[0].ToString() + "'; ";
                naredba = new SqlCommand(sql, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
                cnn.Close();
                refresh();
            }
            catch
            {
                MessageBox.Show("nije odabran item");
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string trenutni = listBox1.SelectedItem.ToString();
                string[] kakgod = trenutni.ToString().Split(')');
                /*
                                SqlCommand naredba;
                                SqlDataReader dataReader2;

                                string cs; //connection string
                                Spajanje cnn = Spajanje.Instance;
                                cnn.Open();
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                string sql = "";
                                sql = "UPDATE Users SET Active = 'True' WHERE ID = '" + kakgod[0].ToString() + "'; ";
                */

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

                sql = "SELECT * FROM Users WHERE ID = '"+ kakgod[0].ToString() + "'";

                cnn.Open();
                naredba = new SqlCommand(sql, cnn.GetConnection());
                dataReader = naredba.ExecuteReader();
                while (dataReader.Read())
                {
                        ID = dataReader.GetValue(0).ToString();
                        username = dataReader.GetValue(1).ToString();
                        password = dataReader.GetValue(2).ToString();
                        Fullname = dataReader.GetValue(3).ToString();
                }

               

                naredba.Dispose();
                cnn.Close();

                sql = "SELECT * FROM UserPrava WHERE UserID = '" + kakgod[0].ToString() + "'";
                cnn.Open();
                output = "";
                naredba = new SqlCommand(sql, cnn.GetConnection());
                dataReader2 = naredba.ExecuteReader();
                while (dataReader2.Read())
                {

                    output = dataReader2.GetValue(0).ToString();

                    if (dataReader2.GetValue(1).ToString() == ID && dataReader2.GetValue(3).ToString() == "True")
                    {
                            prava = prava + dataReader2.GetValue(2).ToString();

                    }
                }
                naredba.Dispose();
                cnn.Close();
                MessageBox.Show("" + ID + username + password + Fullname+prava);

                Edit dF = new Edit(ID,username, password, prava, Fullname);
                dF.Show();

                /*
                naredba = new SqlCommand(sql, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
                cnn.Close();
                */
            }
            catch
            {
                MessageBox.Show("nije odabran item");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            glavni_menu dF = new glavni_menu(username, password, ID, prava, Fullname);
            dF.Show();
        }
    }
}
