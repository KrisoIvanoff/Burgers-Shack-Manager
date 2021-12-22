using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BurgeriVisual
{
    public partial class LoginPanel : Form
    {
        public LoginPanel()
        {
            InitializeComponent();

        }
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
        SqlParameter paramUserName = new SqlParameter("@userName",SqlDbType.VarChar);
        SqlParameter paramUserPass = new SqlParameter("@userPass",SqlDbType.VarChar);
        public static int userId = 0;
        string ordereruserName = "";
        private void loginbtn_Click(object sender, EventArgs e)
        {
            paramUserName.Value = userName.Text;
            paramUserPass.Value = userPass.Text;
            SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            using (sqlcon)
            {


                if (paramUserName.Value.ToString() != string.Empty && paramUserPass.Value.ToString() != string.Empty)
                {

                    SqlCommand cmd = new SqlCommand("select * from burgers.userprofiles where username=@userName and password=@userPass", sqlcon);
                    cmd.Parameters.Add(paramUserName); cmd.Parameters.Add(paramUserPass);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        int adminCheck = Convert.ToInt16(dr["isAdmin"]);

                        if (adminCheck == 1)
                        {
                            adminForm af = new adminForm();
                            this.Hide();
                            af.Show();
                        }
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
                    else
                    {
                        dr.Close();
                        MessageBox.Show("Ba... Prerovih cqlata BD, takoz chudo nema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ae narkoman napishi neshto e", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ShopStatus()
        {

            SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", sqlcon);
            sqlcon.Open(); byte isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar()); sqlcon.Close();
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
        private void rebtn_Click(object sender, EventArgs e)
        {
            string uname = userName.Text.ToString();
            string upass = userPass.Text.ToString();
            ordereruserName = uname;
            bool usernameIsTaken = false;
            SqlConnection conn2 = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");

            SqlCommand checkUsernameAvailability = new SqlCommand("SELECT * from burgers.userprofiles where username = @userName;", conn2);
            paramUserName.Value = userName.Text;
            checkUsernameAvailability.Parameters.Add(paramUserName);
            conn2.Open();
            using(conn2)
            {
                SqlDataReader availabilityChecker = checkUsernameAvailability.ExecuteReader();
                if (availabilityChecker.Read()) 
                 usernameIsTaken = true;
            }
            sqlcon.Open();
            using (sqlcon)
            {
                if (usernameIsTaken == true)
                {
                    MessageBox.Show("Error! Username taken.");
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM burgers.userprofiles WHERE username=@userName AND password= + @userPass+ ;", sqlcon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Tva mi e poznato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else if (userPass.Text == string.Empty || userName.Text == string.Empty) { MessageBox.Show("Gospodin narkoman pls populni vs"); }
                    else if (userPass.Text != string.Empty && userName.Text != string.Empty)
                    {
                        dr.Close();

                        string qry1 = "INSERT INTO burgers.userprofiles(userprofiles.username,userprofiles.password,userprofiles.isAdmin) VALUES ( @userName  , @userPass ,0)";;
                        cmd = new SqlCommand(qry1, sqlcon);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
    }

        private void LoginPanel_Load(object sender, EventArgs e)
        {
            ShopStatus();
            RefreshLbl();
        }

        private void RefreshLbl()
        {
            var refresh = new System.Windows.Forms.Timer { Interval = 1000 };
            refresh.Tick += (sender, args) => timer_Tick(sender,args);
            refreshStatus.Interval = 1000;
            refreshStatus.Tick += new EventHandler(timer_Tick);
            refreshStatus.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=DESKTOP-JKT9IB6;Database=burgers;Integrated Security=true");
SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", conn);
            conn.Open(); byte isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar()); conn.Close();
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