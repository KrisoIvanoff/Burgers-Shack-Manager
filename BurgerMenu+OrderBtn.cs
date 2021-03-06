using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BurgeriVisual
{
    public partial class BurgerMenu_OrderBtn : Form
    {
        public int localUserId = 0;
        public BurgerMenu_OrderBtn(int userid, string username)
        {
            InitializeComponent();
            localUserId = userid;
            uname = username;
        }
        string uname;
        SqlConnection sqlcon = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
        private void BurgerMenu_OrderBtn_Load(object sender, EventArgs e)
        {
            GetMenu();
            GetPastOrders();
            UpdateStatus();
        }
        private void GetMenu()
        {
            DataSet ds = new DataSet();
            sqlcon.Open();
            using (sqlcon)
            {
                SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM burgers.burgerTypes", sqlcon);
                dataadapter.Fill(ds, "burgerName");
                bigmenu.DataSource = ds;
                bigmenu.DataMember = "burgerName";
                this.bigmenu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void GetPastOrders()
        {
            SqlConnection pastordconn = new SqlConnection("server=DESKTOP-JKT9IB6;database=burgers;Integrated Security=true;");
            pastordconn.Open();
            using (pastordconn)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter burgName = new SqlDataAdapter("SELECT orderid,burgertypes.burgername,quantity,commentary,deliveryAddr,isDelivered from burgers.burgertypes,dbo.orders WHERE burgertypes.id = dbo.orders.burgertype AND dbo.orders.userid = " + localUserId, pastordconn);
                burgName.Fill(ds, "orders");
                pastOrders.DataSource = ds;
                pastOrders.DataMember = "orders";
            }
        }
        byte isOpenVar = 0;
        private void orderbtn_Click(object sender, EventArgs e)
        {

            if (isOpenVar == 1)
            {
                this.Hide();
                userorder a = new userorder(localUserId, uname);
                a.Show();
            }
            else if (isOpenVar == 0)
            {
                MessageBox.Show("This shop is currently closed!At the moment,you cannot buy anything!");
            }
        }
        private void UpdateStatus()
        {
            refreshOrderBtn.Interval = 1000;
            refreshOrderBtn.Tick += new EventHandler(timer_Tick);
            refreshOrderBtn.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            SqlCommand checkShopStatus = new SqlCommand("SELECT isOpen from dbo.shopstatus", sqlcon);
            sqlcon.Open();
            using (sqlcon)
                isOpenVar = Convert.ToByte(checkShopStatus.ExecuteScalar());
        }
    }
}