﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public static int userId = 0;
        string ordereruserName = "";
        private void loginbtn_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            if (sqlcon.State == ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            using (sqlcon)
            {


                if (userName.Text != string.Empty && userPass.Text != string.Empty)
                {

                    SqlCommand cmd = new SqlCommand("select * from burgers.userprofiles where username='" + userName.Text + "' and password='" + userPass.Text + "'", sqlcon);
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
                statuslbl.Text = "Shop is currently opened";
            }
            else
            {
                statuslbl.ForeColor = Color.Red;
                statuslbl.Text = "Shop is currently closed. Limited actions";
            }
        }
        private void rebtn_Click(object sender, EventArgs e)
        {
            string uname = userName.Text.ToString();
            string upass = userPass.Text.ToString();
            ordereruserName = uname;
            bool usernameIsTaken = false;
            SqlConnection conn2 = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");

            SqlCommand checkUsernameAvailability = new SqlCommand("SELECT * from burgers.userprofiles where username = '"+ uname + "';", conn2);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM burgers.userprofiles WHERE username='" + @uname + "' AND password='" + @upass + "';", sqlcon);
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

                        string qry1 = "INSERT INTO burgers.userprofiles(userprofiles.username,userprofiles.password,userprofiles.isAdmin) VALUES (\'" + uname + "\',\'" + upass + "\',0);";
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
        }
    }
}