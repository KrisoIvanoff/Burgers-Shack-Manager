using System;
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
namespace BurgeriVisual
{
    public partial class BurgerMenu_OrderBtn : Form
    {
        public int localUserId = 0;
        public BurgerMenu_OrderBtn(int userid)
        {
            InitializeComponent();
            localUserId = userid;
        }
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
        private void BurgerMenu_OrderBtn_Load(object sender, EventArgs e)
        {
            GetMenu();
            GetPastOrders();
        }

        private void BigMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void GetMenu()
        {
                DataSet ds = new DataSet();

                SqlCommand com = new SqlCommand("SELECT * FROM burgers.burgerTypes", sqlcon);
            sqlcon.Open();
                using (sqlcon)
                {
                    using (com)
                    {
                        SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sqlcon);
                        dataadapter.Fill(ds, "burgerName");
                        bigmenu.DataSource = ds;
                        bigmenu.DataMember = "burgerName";
                        this.bigmenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
        }

        private void GetPastOrders()
        {
            SqlConnection pastordconn= new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            pastordconn.Open();
            DataSet ds = new DataSet();
            //                SqlDataAdapter burgName = new SqlDataAdapter("SELECT burgers.burgertypes.burgerName, orders.orderid, orders.commentary, orders.deliveryAddr, orders.quantity, burgers.userprofiles.username FROM burgers.burgertypes INNER JOIN orders ON burgers.burgertypes.id = orders.burgertype INNER JOIN burgers.userprofiles ON orders.userid = burgers.userprofiles.id WHERE orders.userid = " + localUserId, pastordconn);
            SqlDataAdapter burgName = new SqlDataAdapter("SELECT burgers.burgertypes.burgerName, orders.orderid, orders.commentary, orders.deliveryAddr, orders.quantity, userprofiles.username FROM burgers.burgertypes,burgers.userprofiles,dbo.orders WHERE orders.userid = " + localUserId, pastordconn);
            MessageBox.Show(localUserId.ToString());
                    burgName.Fill(ds, "orders");
                    pastOrders.DataSource = ds;
                    pastOrders.DataMember = "orders";
                    pastordconn.Close();
        }
        private void bigmenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void hiddenUserIdlbl_Click(object sender, EventArgs e)
        {

        }

        private void orderbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            userorder a = new userorder();
            a.Show();
        }
    }
}
