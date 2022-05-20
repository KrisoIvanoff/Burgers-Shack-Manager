using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BurgeriVisual
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();

        }
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
        public static int userId = 0;
        string ordereruserName;
        //this is the login function
        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            using (sqlcon)
            {

                if (userName.Text != string.Empty && userPass.Text != string.Empty)
                {
                    //checks if the credentials match

                    SqlCommand cmd = new SqlCommand("select * from burgers.userprofiles where username='" + userName.Text + "' and password='" + userPass.Text + "'", sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    //if the credentials do actually match
                    if (dr.Read())
                    {
                        bool adminCheck = Convert.ToBoolean(dr["isAdmin"]);
                        //admin panel launch
                        if (adminCheck == true)
                        {
                            adminForm af = new adminForm();
                            this.Hide();
                            af.Show();
                        }
                        //launch user GUI
                        else
                        {
                            ordereruserName = userName.Text;
                            userId = Convert.ToInt32(dr["id"]);
                            dr.Close();
                            BurgerMenu_OrderBtn obj1 = new BurgerMenu_OrderBtn(userId, userName.Text);
                            obj1.Show();
                            this.Hide();
                        }
                    }
                    //exceptions
                    else
                    {
                        dr.Close();
                        MessageBox.Show("Ba... Prerovih cqlata BD, takoz chudo nema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Field/s empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //this checks the shop status onStart
        private void ShopStatus()
        {
            byte isOpenVar;
            SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", sqlcon);
            sqlcon.Open();
            using(sqlcon)
             isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar());
            if (isOpenVar == 1)
            {
                statuslbl.ForeColor = Color.Green;
                statuslbl.Text = "Shop is currently open.";
            }
            else
            {
                statuslbl.ForeColor = Color.Red;
                statuslbl.Text = "Shop is currently closed. No new orders.";
            }
        }
        //for the register button
        private void rebtn_Click(object sender, EventArgs e)
        {
            string uname = userName.Text.ToString();
            string upass = userPass.Text.ToString();
            ordereruserName = uname;
            SqlConnection conn2 = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            conn2.Open();
            using (conn2)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM burgers.userprofiles WHERE username='" + @uname + "' AND password='" + @upass + "';", sqlcon);
                SqlDataReader dr = cmd.ExecuteReader();
                //checks if the username is taken or not
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Error! Username taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                //if it goes here, the username is not taken
                else if (userPass.Text == string.Empty || userName.Text == string.Empty) { MessageBox.Show("Gospodin narkoman pls populni vs"); }
                else if (userPass.Text != string.Empty && userName.Text != string.Empty)
                {
                    dr.Close();

                    string qry1 = "INSERT INTO burgers.userprofiles(userprofiles.username,userprofiles.password,userprofiles.isAdmin) VALUES (\'" + uname + "\',\'" + upass + "\',0);";
                    cmd = new SqlCommand(qry1, sqlcon);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void LoginPanel_Load(object sender, EventArgs e)
        {
            ShopStatus();
            RefreshLbl();
            userPass.PasswordChar = 'x';
        }
        private void RefreshLbl()
        {
            refreshStatus.Interval = 1000;
            refreshStatus.Tick += new EventHandler(timer_Tick);
            refreshStatus.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            byte isOpenVar;
            SqlConnection conn = new SqlConnection("Server=DESKTOP-JKT9IB6;Database=burgers;Integrated Security=true");
            SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", conn);
            conn.Open(); using (conn)
            { isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar());} 
            if (isOpenVar == 1)
            {
                statuslbl.ForeColor = Color.Green;
                statuslbl.Text = "Shop is currently open.";
            }
            else
            {
                statuslbl.ForeColor = Color.Red;
                statuslbl.Text = "Shop is currently closed. No new orders.";
            }
        }
    }
}