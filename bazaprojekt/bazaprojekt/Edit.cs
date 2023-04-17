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
    public partial class Edit : Form
    {

        string ID="";
        public Edit(string IDf, string username, string password, string prava, string Fullname)
        {
            InitializeComponent();
            textBox1.Text = Fullname;
            textBox2.Text = username;
            textBox3.Text = password;
            if (prava.Contains("1"))
            {
                checkBox1.Checked = true;
            }
            if (prava.Contains("2"))
            {
                checkBox2.Checked = true;
            }
            if (prava.Contains("3"))
            {
                checkBox3.Checked = true;
            }
            if (prava.Contains("4"))
            {
                checkBox4.Checked = true;
            }
            if (prava.Contains("5"))
            {
                checkBox5.Checked = true;
            }
            if (prava.Contains("6"))
            {
                checkBox6.Checked = true;
            }
            ID = IDf;

        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand naredba;
            SqlDataReader dataReader2;

            string cs; //connection string
            Spajanje cnn = Spajanje.Instance;
            cnn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = "UPDATE Users SET Username='" + textBox2.Text + "', Password='" + CreateMD5(textBox3.Text) + "', Fullname='" + textBox1.Text + "' WHERE ID='" + ID+"'; ";
            naredba = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand = new SqlCommand(sql, cnn.GetConnection());
            adapter.InsertCommand.ExecuteNonQuery();
            cnn.Close();


            cnn.Open();
            string sql3 = "";
            bool jen=checkBox1.Checked;
            bool dva = checkBox2.Checked;
            bool tri = checkBox3.Checked;
            bool cetri = checkBox4.Checked;
            bool pet = checkBox5.Checked;
            bool set = checkBox6.Checked;


            sql3 = "UPDATE  UserPrava SET  Aktivno='" + jen + "' WHERE UserID='" + ID + "' AND PravoID=1 ; ";
                naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();


            sql3 = "UPDATE  UserPrava SET  Aktivno='" + dva + "' WHERE UserID='" + ID + "' AND PravoID=2 ; ";
            naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();


            sql3 = "UPDATE  UserPrava SET  Aktivno='" + tri + "' WHERE UserID='" + ID + "' AND PravoID=3 ; ";
            naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
               adapter.InsertCommand.ExecuteNonQuery();


            sql3 = "UPDATE  UserPrava SET  Aktivno='" + cetri + "' WHERE UserID='" + ID + "' AND PravoID=4 ; ";
            naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();


            sql3 = "UPDATE  UserPrava SET  Aktivno='" + pet + "' WHERE UserID='" + ID + "' AND PravoID=5 ; ";
            naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();

            sql3 = "UPDATE  UserPrava SET  Aktivno='" + set + "' WHERE UserID='" + ID + "' AND PravoID=6 ; ";
            naredba = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand = new SqlCommand(sql3, cnn.GetConnection());
                adapter.InsertCommand.ExecuteNonQuery();
            
            cnn.Close();

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

    }
}
